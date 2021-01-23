    foreach (OldCombo oldCmbx in OldCmbxs())
    {
      bool _visible = GetVisiblePropThroughReflection(designerHost.GetDesigner(oldCmbx));
      ...
      NewCombo newCmbx = designerHost.CreateComponent(NewComboType, oldcmbx.Name) as NewCmbx;
      ...
      SetVisiblePropThroughReflection(designerHost.GetDesigner(newCmbx), _visible);
      ...
      designerHost.DestroyComponent(oldCmbx);
    }
