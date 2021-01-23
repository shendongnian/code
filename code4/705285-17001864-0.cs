    public UserMap() {
        this.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(100);
        this.Property(t => t.Password)
            .IsRequired()
            .HasMaxLength(15);
        this.Property(t => t.Username)
            .IsRequired()
            .HasMaxLength(15);
        this.HasOptional(t => t.UserProfile)
            .WithRequired(t => t.User);
    }
