      public class SegmentMap : EntityTypeConfiguration<Segment>
    {
        public SegmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(255);
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
          this.Property(t => t.GeometryParameters)
            .IsRequired()
            .HasMaxLength(512);
            // Table & Column Mappings
            this.ToTable("Segment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NetworkId).HasColumnName("NetworkId");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SourceIndex).HasColumnName("SourceIndex");
            this.Property(t => t.TargetIndex).HasColumnName("TargetIndex");
            this.Property(t => t.IsInitialized).HasColumnName("IsInitialized");
            this.Property(t => t.NeighborNodeDistance).HasColumnName("NeighborNodeDistance");
            this.Property(t => t.GeometryParameters).HasColumnName("GeometryParameters");
            this.Property(t => t.SourceNodeId).HasColumnName("SourceNodeId");
            this.Property(t => t.TargetNodeId).HasColumnName("TargetNodeId");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.TrackName).HasColumnName("TrackName");
            this.Property(t => t.IsTrackNameFixed).HasColumnName("IsTrackNameFixed");
            // Relationships
            this.HasRequired(t => t.Network)
                .WithMany(t => t.Segments)
                .HasForeignKey(d => d.NetworkId);
        }
    }
