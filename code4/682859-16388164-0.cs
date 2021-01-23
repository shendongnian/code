    public class BtceApiAsync
    {
        public Task<Ticker> GetTickerAsync(BtcePair pair)
        {
            return Task.Run(() => BtceApi.GetTicker(pair));
        }
        // etc
    }
