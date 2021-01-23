    private readonly ObservableCollection<AttributeValuesLibrary> _availableShapesCollection =
        new ObservableCollection<AttributeValuesLibrary>();
    private readonly ObservableCollection<AttributeValuesLibrary> _availableColorsCollection =
        new ObservableCollection<AttributeValuesLibrary>();
    public ObservableCollection<AttributeValuesLibrary> AvailableShapesCollection
    {
        get { return _availableShapesCollection; }
    }
    public ObservableCollection<AttributeValuesLibrary> AvailableColorsCollection
    {
        get { return _availableColorsCollection; }
    }
    public AttributeValuesLibrary SelectedShape
    {
        get { return _selectedShape; }
        set
        {
            if (_selectedShape != value)
            {
                _selectedShape = value;
                RaisePropertyChanged("SelectedShape");
                SelectedShapeChanged();
            }
        }
    }
    public ObservableCollection<ConnectorPartNumber> ConnAttPNResults
    {
        get { return _resultingPNsIntersect; }
        set
        {
            if (_resultingPNsIntersect != value)
            {
                this._resultingPNsIntersect = value;
                RaisePropertyChanged("ResultingPNsIntersect");
                UpdateAvailableOptions();
            }
        }
    }
    private void SelectedShapeChanged()
    {
        // If a shape has been selected, we need to navigate to it's related 
        // PartNumbers and add those to the intersection contained by ResultingPNsIntersection. 
        if (_selectedShape != null)
        {
            var shapeResults = _context.PartNumbers.Where(x => x.AttributeValuesLibrary_Shape.AttValID == _selectedShape.AttValID);
            if (_resultingPNsIntersect != null)
            {
                var resultsFromPreviousSelection = _resultingPNsIntersect;
                ConnAttPNResults = new ObservableCollection<PartNumber>(resultsFromPreviousSelection.Intersect(shapeResults));
            }
            else
            {
                ConnAttPNResults = new ObservableCollection<PartNumber>(shapeResults);
            }
        }
    }
    private void UpdateAvailableOptions()
    {
        if (_resultingPNsIntersect != null)
        {
            _availableColorsCollection.Clear();
            _availableShapesCollection.Clear();
            foreach (PartNumber color in _resultingPNsIntersect.Where(x => x.ColorID != null).Distinct())
            {
                _availableShapesCollection.Add(color.AttributeValuesLibrary_Color);
            }
            foreach (PartNumber shape in _resultingPNsIntersect.Where(x => x.ShapeID != null).Distinct())
            {
                shapes.Add(shape.AttributeValuesLibrary_Shape);
            }
        }
    }
