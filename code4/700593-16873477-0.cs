    public MilestoneItemViewModel SelectedMilestoneItem
    {
        get
        {
            return selectedMilestoneItem;
        }
        set
        {
            selectedMilestoneItem = value;
            selectedMilestoneItem.CheckBoxValue = true;
            NotifyPropertyChange("SelectedMilestoneItem");
        }
    }
