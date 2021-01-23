    private static void OnSelectedMemberPropertyChanged(DependencyObject m, DependencyPropertyChangedEventArgs args)
    {
      var b = m as OverviewViewModel;
      if (b == null)
        return;
      var selectedMember = m.GetValue(SelectedItemProperty) as MemberViewModel;
      b.selectedMemberChanged(selectedMember);
    }
