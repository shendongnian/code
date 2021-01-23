    public bool AddNewSection(string SectionTitle, out string newSectionId)
            {
                try
                {
                    string CurrParentId;
                    string CurrParentName;
                    string strPath;
                    CurrParentId = FindCurrentlyViewedSectionGroup(out CurrParentName);
                    if (string.IsNullOrWhiteSpace(CurrParentId) || string.IsNullOrWhiteSpace(CurrParentName))
                    {
                        CurrParentId = FindCurrentlyViewedNotebook(out CurrParentName);
                        if (string.IsNullOrWhiteSpace(CurrParentId) || string.IsNullOrWhiteSpace(CurrParentName))
                        {
                            newSectionId = string.Empty;
                            return false;
                        }
                        strPath = FindCurrentlyViewedItemPath("Notebook");
                    }
                    else
                        strPath = FindCurrentlyViewedItemPath("SectionGroup");
    
                    if (string.IsNullOrWhiteSpace(strPath))
                    {
                        newSectionId = string.Empty;
                        return false;
                    }
                    
                    SectionTitle = SectionTitle.Replace(':', '\\');
                    SectionTitle = SectionTitle.Trim('\\');
                    strPath += "\\" + SectionTitle + ".one";
                    onApp.OpenHierarchy(strPath, null, out newSectionId, Microsoft.Office.Interop.OneNote.CreateFileType.cftSection);
                    onApp.NavigateTo(newSectionId, "", false);
                }
                catch
                {
                    newSectionId = string.Empty;
                    return false;
                }
                return true;
            }
            
