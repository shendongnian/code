    if (view.SelectedCharacteristics != null)
    {
        CharacFilter = view.SelectedCharacteristics.Select(cf => cf.Id);
    }
    else
    {
        CharacFilter = new List<int>();
    }
