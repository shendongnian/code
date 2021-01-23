    foreach (var tagControl in taggedContentControls)
                    {
                        string tagName = tagControl.Descendants<SdtAlias>().First().Val.Value;
                        if (tagName.Contains("Test Tag"))
                        {
    // If we want to delete table only
                            //tagControl.SdtContentBlock.Descendants<Table>().First().Remov();       
    // If you want to remove everything in this tag                        
    sdtBlock.SdtContentBlock.Remove();
                        }
                    }
