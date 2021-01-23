    public Region RegionContext
    {
        get
        {
            if (this.user != null &&
                this.user.Region!= null)
                return this.user.Region;
            var region= _region.GetAllRegions().FirstOrDefault();
            return region;
        }
        set
        {
            if (this.user == null)
                return;
            this.user.region = value;
            _user.UpdateUser(this.User);
        }
    }
