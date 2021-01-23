    var result = from m in Media
             
                 join g in Galleries
                   on m.GalleryId equals g.GalleryId
                 into gJoinData
                 from gJoinRecord in gJoinData.DefaultIfEmpty( )
                 where m.MediaDate.CompareTo( DateTime.Today.AddDays( -30.0 ) ) >= 0
                 orderby m.Views descending
                 
                 select new
                 {
                     M_Record = m,
                     GalleryTitle = gJoinRecord.GalleryTitle
                 };
                 
            
