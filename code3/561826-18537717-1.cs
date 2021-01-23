    class MyCalendar : Calendar 
    {
        public Button PrevBtn;
        public Button NextBtn;
        protected bool _HidePrevNextBtns;
        public bool HidePrevNextBtns
        {
            get
            {
                return (_HidePrevNextBtns);
            }
            set
            {
                _HidePrevNextBtns = value;
                if (PrevBtn != null)
                {
                    PrevBtn.Visibility = _HidePrevNextBtns ? Visibility.Hidden : Visibility.Visible;
                    NextBtn.Visibility = _HidePrevNextBtns ? Visibility.Hidden : Visibility.Visible;
                }
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var cal = this.Template.FindName("PART_CalendarItem", this) as CalendarItem;
            cal.Loaded += new RoutedEventHandler(cal_Loaded);
        }
        void cal_Loaded(object sender, RoutedEventArgs e)
        {
            var cal = sender as CalendarItem;
            PrevBtn = cal.Template.FindName("PART_PreviousButton", cal) as Button;
            NextBtn = cal.Template.FindName("PART_NextButton", cal) as Button;
            if (_HidePrevNextBtns)
            {
                PrevBtn.Visibility = Visibility.Hidden;
                NextBtn.Visibility = Visibility.Hidden;
            }
        }
    }
