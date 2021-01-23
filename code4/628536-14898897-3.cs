    public class Video { }
    public class ImageInfo {
        public virtual Video { get; set; }
    }
    modelBuilder
        .Entity<ImageInfo>()
        .HasRequired(v => v.Video)
        .WithMany()
        .WillCascadeOnDelete(true);
