    var isPublishing = SPContext.Current.FormContext.FormMode != SPControlMode.Invalid;
    var wpDMode = WebPartManager.GetCurrentWebPartManager(Page).DisplayMode.Name;
    var isEditing = isPublishing
         ? SPContext.Current.FormContext.FormMode != SPControlMode.Display
         : (wpDMode.Equals("Edit") || wpDMode.Equals("Design"));
