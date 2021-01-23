    private void PopulateStringDropdownList(List<ObjectInfo> listObjects, object selectedType = null)
    
            {
                List<string> listString = listObjects.OrderBy(x => x.m_Type)
                                                 .Select(x => x.m_Type.ToString())
                                                 //.Distinct()
                                                 .ToList();
                ViewBag.cardType = new SelectList(listString );
            }
