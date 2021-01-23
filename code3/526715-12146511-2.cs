            doc.PrintPage+=(s, pe) =>
            {
                Rectangle client = new Rectangle(
                    pe.PageBounds.Left, 
                    pe.PageBounds.Top,
                    userControl11.ClientSize.Width-1,
                    userControl11.ClientSize.Height-1 );
                userControl11.Render(pe.Graphics, client);
                pe.HasMorePages=false;                
            };
