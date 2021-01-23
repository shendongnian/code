public class FileEntity
{
	public Guid FileGuid { get; private set; }
	public byte[] Document { get; private set; }
}
And this configuration:
public class FileEntityConfiguration : IEntityTypeConfiguration<FileEntity>
{
	public void Configure(EntityTypeBuilder<FileEntity> builder)
	{
		builder
			.Property(m => m.Document)
			.HasColumnType("VARBINARY(MAX) FILESTREAM");
		builder
			.Property(m => m.FileGuid)
			.HasColumnType("UNIQUEIDENTIFIER ROWGUIDCOL")
			.IsRequired();
		builder
			.HasAlternateKey(m => m.FileGuid);
	}
}
EF generates a correct migration script:
FileGuid = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false),
Document = table.Column<byte[]>(type: "VARBINARY(MAX) FILESTREAM", nullable: true)
