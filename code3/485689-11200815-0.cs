    foreach (Block block in rtb.Blocks)
            {
                if (block is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)block;
                    foreach (Inline inline in paragraph.Inlines)
                    {
                        if (inline is InlineUIContainer)
                        {
                            InlineUIContainer uiContainer = (InlineUIContainer)inline;
                            if (uiContainer.Child is Image)
                            {
                                Image image = (Image)uiContainer.Child;
    //Copy Image source to another repository folder and save the path.
                            }
                        }
                    }
                }
