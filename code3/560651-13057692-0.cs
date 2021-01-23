    public sealed class Platform
    {
        public List<Capture> Captures { get; set; }
        // the rest of the stuff
    }
...
    var query = this._defaultContext.Platforms.Include("Captures").Select(p => new { Platform = p, CaptureCount = p.Captures.Count() });
