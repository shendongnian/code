            private BeginStoryboard _beginStoryBoard;
            private RemoveStoryboard _removeStoryboard;
            protected override void OnAttached()
            {
                _orignalStyle = AssociatedObject.Style;
                _beginStoryBoard = new BeginStoryboard { Storyboard = CreateStoryboard() };
                _beginStoryBoard.Name = "terribleUi";
                _removeStoryboard = new RemoveStoryboard();
                _removeStoryboard.BeginStoryboardName = _beginStoryBoard.Name; 
                AssociatedObject.Style = CreateShakeStyle();
                AssociatedObject.Style.RegisterName("terribleUi", _beginStoryBoard);
            }
