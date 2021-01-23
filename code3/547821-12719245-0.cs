    var sliderModelList = sliderRecordList.AsEnumerable.Select(record => new SliderModel()
          {
            Id = record.Id,
            SlideName = record.SlideName,
            SlideOrder = record.SlideOrder,
            SlideUrl = record.SlideUrl,
            SlideImageUrl = Url.Content("~/Content/AhsenSliderImages/" + record.Id + ".jpg"),
            Enabled = record.Enabled
       });
