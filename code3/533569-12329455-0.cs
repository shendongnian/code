     public struct IMAGE_DOS_HEADER : IEnumerable<UInt16>
        {      // DOS .EXE header
            public UInt16 e_magic;              // Magic number
            public UInt16 e_cblp;               // Bytes on last page of file
            public UInt16 e_cp;                 // Pages in file
            public UInt16 e_crlc;               // Relocations
            public UInt16 e_cparhdr;            // Size of header in paragraphs
            public UInt16 e_minalloc;           // Minimum extra paragraphs needed
    
    
            public IEnumerator<UInt16> GetEnumerator()
            {
                return (IEnumerator<UInt16>)(new[] {e_magic, e_cblp, e_cp, e_crlc, e_cparhdr, e_minalloc}.GetEnumerator());
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return new[] { e_magic, e_cblp, e_cp, e_crlc, e_cparhdr, e_minalloc }.GetEnumerator();
            }
        }
