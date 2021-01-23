    /// <summary>A set of pictures</summary>
    public struct PictureSet
    {
        public int Offset { get; private set; }
        public IList<Picture> Pictures { get; private set; }
        /// <summary>Clients will use this property if they want to pick up where they left off</summary>
        public int NextOffset { get { return Offset + Pictures.Count; } }
        public PictureSet(int offset, IList<Picture> pictures)
            :this() { Offset = offset; Pictures = pictures; }
    }
    public class PictureProvider : IPictureProvider<PictureSet>
    {
        public IObservable<PictureSet> GetPictures(int offset = 0)
        {
            // use Defer() so we can capture a copy of offset
            // for each observer that subscribes (so multiple
            // observers do not update each other's offset
            return Observable.Defer<PictureSet>(() =>
            {
                var localOffset = offset;
                // Use Defer so we re-execute GetPageAsync()
                // each time through the loop.
                // Update localOffset after each GetPageAsync()
                // completes so that the next call to GetPageAsync()
                // uses the next offset
                return Observable.Defer(() => GetPageAsync(localOffset))
                    .Select(pictures =>
                        {
                            var s = new PictureSet(localOffset, pictures);
                            localOffset += pictures.Count;
                        })
                    .Repeat()
                    .TakeWhile(pictureSet => pictureSet.Pictures.Count > 0);
            });
        }
        private async Task<IList<Picture>> GetPageAsync(int offset)
        {
            var data = await BoringWebServiceCallAsync(offset);
            result = data.Pictures.ToList();
        }
        // this version uses Observable.Run() (which just uses Task.Run under the hood)
        // in case you cannot convert your
        // web service call to be asynchronous
        private IObservable<IList<Picture>> GetPageAsync(int offset)
        {
            return Observable.Run(() =>
            {
                var result = new List<Picture>();
                ... boring web service call here
                return result;
            });
        }
    }
