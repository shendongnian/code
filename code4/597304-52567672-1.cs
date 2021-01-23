    public class VehicleSeriesViewModel
        {
            public Guid VehicleBadgeId { get; set; }
            public Guid VehicleSeriesId { get; set; }
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
            public IFormFile FileUpload { get; set; }
            public string PictureUrl { get; set; }
        }
