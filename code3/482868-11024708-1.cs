        public DynamicRepo(bool Main = true, bool Archive = false)
        {
            if (Main)
            {
                this.context = new MainDbContext();
            }
            if (Archive)
            {
                this.context = new ArchiveDbContext();
            }
        }
