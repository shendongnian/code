    var query = this._defaultContext.Captures
                        .GroupBy(m => m.Platform, new PlatformEqualityComparer())
                        .Select(m => new {
                            Platform = m.Key,
                            Count = m.Count()
                        });
    class PlatformEqualityComparer : IEqualityComparer<Platform>
    {
        public bool Equals(Platform x, Platform y)
        {
            return x.Id.Equals(y.Id)
        }
        public int GetHashCode(Platform obj)
        {
            return obj.Id.GetHashCode();
        }
    }
