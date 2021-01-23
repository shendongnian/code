    tempPanels = new Panel[panels.Length];
    Array.Copy(panels, 1, tempPanels, 0, panels.Length - 1);//delete the oldest history log (the first of the array)
    // Dispose of every element in the array
    for (int i = 0; i < panels.Length; i++)
        panels[i].Dispose();
    // The following line is unneccessary, as the variable is re-assigned anyway
    // panels = null; //empty object array
    panels = new Panel[tempPanels.Length + 1]; //set new length
    tempPanels.CopyTo(panels, 0);//restore panels
