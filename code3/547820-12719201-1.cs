    var sliderRecordList = this._sliderService.GetAllAsQueryable().ToList();
    var sliderModelList = sliderRecordList
       .Select(record => new SliderModel
          {
            Id = record.Id,
            SlideName = record.SlideName,
            SlideOrder = record.SlideOrder,
            SlideUrl = record.SlideUrl,
            SlideImageUrl = Url.Content("~/Content/AhsenSliderImages/" + record.Id + ".jpg"),
            Enabled = record.Enabled
       });
