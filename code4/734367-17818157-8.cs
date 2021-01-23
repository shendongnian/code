            public class SparseRange
            {
                public SparseRange(long fileOffset, long length)
                {
                    this.FileOffset = FileOffset; // the right hand side should be fileOffset
                    this.Length = length;
                }
                public long FileOffset { get; set; }
                public long Length { get; set; }
            }
