        public ActionResult StatsVideo(int Id)
        {
            IStatsVideo vid = StatsVideoService.GetEntity(new Lookup(TableStatsVideo.StatsVideoId, Id));
            if (vid == null)
                vid = StatsVideoService.GetEntityList(new Lookup(TableStatsVideo.IsDeleted, false)).OrderByDescending(x => x.DateCreated).FirstOrDefault();
            return PartialView(vid);
        }
