    public class ProfilePicture
    {
        public string Filename { get; set; }
    }
    public class ProfilePics : IEnumerable<ProfilePicture>
    {
        public List<ProfilePicture> Pictures = new List<ProfilePictures>();
        public IEnumerator<ProfilePicture> GetEnumerator()
        {
            foreach (var pic in Pictures)
                yield return pic;
            // or simply "return Pictures.GetEnumerator();" but the above should
            // hopefully be clearer
        }
    }
