    using RangeSlider;
    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Shapes;
    [TemplatePart(Name = ThumbPartName_Upper, Type = typeof(Thumb))]
    [TemplatePart(Name = ThumbPartNameLower, Type = typeof(Thumb))]
    [TemplatePart(Name = RectanglePartName, Type = typeof(Rectangle))]
    [TemplatePart(Name = RangeValueControl, Type = typeof(ItemsControl))]
    [TemplatePart(Name = RangeLastMarkValue, Type = typeof(TextBlock))]
    public class SimpleSlider : Control
    {
        private const string ThumbPartName_Upper = "PART_Thumb_Upper";
        private const string RectanglePartName = "PART_Rectangle_Middle";
        private const string ThumbPartNameLower = "PART_Thumb_Lower";
        private const string RangeValueControl = "PART_ItemsControl_RangeControl";
        private const string RangeLastMarkValue = "PART_Lastmark_TextBlock";
        private Thumb _upperThumb;
        private Thumb _lowerthumb;
        private Rectangle _middleFillRectangle;
        private ItemsControl _scaleValueControl;
        private TextBlock _lastmarkTextblock;
        private int _interval;
        private double _sectionValue;
        private double _interval_width;
        public event EventHandler LowerValueChanged;
        public event EventHandler UpperValueChanged;
        #region Properties
        private bool isThumbSelected = true;
        public bool IsThumbSelected
        {
            get { return isThumbSelected; }
            set { isThumbSelected = value; IsThumb_Selected = value; }
        }
        public static bool IsThumb_Selected { get; set; }
        #endregion
        #region Dependency Properties
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public double LowerValue
        {
            get { return (double)GetValue(LowerValueProperty); }
            set
            {
                SetValue(LowerValueProperty, value);
                RangeEventArgs e = new RangeEventArgs() { NewValue = value };
                if (LowerValueChanged != null)
                    LowerValueChanged(this, e);
            }
        }
        public double UpperValue
        {
            get { return (double)GetValue(UpperValueProperty); }
            set
            {
                SetValue(UpperValueProperty, value);
                RangeEventArgs e = new RangeEventArgs() { NewValue = value };
                if (UpperValueChanged != null)
                    UpperValueChanged(this, e);
            }
        }
        // Using a DependencyProperty as the backing store for UpperValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpperValueProperty =
            DependencyProperty.Register("UpperValue", typeof(double), typeof(SimpleSlider), new PropertyMetadata(0.0, UpperValuePropertyChanged));
        // Using a DependencyProperty as the backing store for LowerValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LowerValueProperty =
            DependencyProperty.Register("LowerValue", typeof(double), typeof(SimpleSlider), new PropertyMetadata(0.0, LowerValuePropertyChanged));
        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(SimpleSlider), new PropertyMetadata(0.0));
        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(SimpleSlider), new PropertyMetadata(0.0));
        // Using a DependencyProperty as the backing store for RangeCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RangeCollectionProperty =
            DependencyProperty.Register("RangeCollection", typeof(List<Range>), typeof(SimpleSlider), new PropertyMetadata(null));
        public List<Range> RangeCollection
        {
            get { return (List<Range>)GetValue(RangeCollectionProperty); }
            set { SetValue(RangeCollectionProperty, value); }
        }
        public double Division
        {
            get { return (double)GetValue(DivisionProperty); }
            set { SetValue(DivisionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Division.  This enables binding scale division width, etc...
        public static readonly DependencyProperty DivisionProperty =
            DependencyProperty.Register("Division", typeof(double), typeof(SimpleSlider), new PropertyMetadata(0));
        public string LastMark
        {
            get { return (string)GetValue(LastMarkProperty); }
            set { SetValue(LastMarkProperty, value); }
        }
        public static readonly DependencyProperty LastMarkProperty =
          DependencyProperty.Register("LastMark", typeof(string), typeof(SimpleSlider), new PropertyMetadata(""));
        public int MinimumInterval
        {
            get { return (int)GetValue(MinimumIntervalProperty); }
            set { SetValue(MinimumIntervalProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinimumInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumIntervalProperty =
            DependencyProperty.Register("MinimumInterval", typeof(int), typeof(SimpleSlider), new PropertyMetadata(5));
        public int MaximumInteraval
        {
            get { return (int)GetValue(MaximumInteravalProperty); }
            set { SetValue(MaximumInteravalProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MaximumInteraval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumInteravalProperty =
            DependencyProperty.Register("MaximumInteraval", typeof(int), typeof(SimpleSlider), new PropertyMetadata(15));
        #endregion
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._upperThumb = this.GetTemplateChild(ThumbPartName_Upper) as Thumb;
            if (this._upperThumb != null)
            {
                this._upperThumb.DragDelta += this.Thumb_DragDelta;
            }
            this._lowerthumb = this.GetTemplateChild(ThumbPartNameLower) as Thumb;
            if (_lowerthumb != null)
            {
                this._lowerthumb.DragDelta += this.Thumb1_DragDelta;
            }
            this._middleFillRectangle = this.GetTemplateChild(RectanglePartName) as Rectangle;
            this._scaleValueControl = this.GetTemplateChild(RangeValueControl) as ItemsControl;
            this._lastmarkTextblock = this.GetTemplateChild(RangeLastMarkValue) as TextBlock;
            this.SizeChanged += new SizeChangedEventHandler(SimpleSlider_SizeChanged);
        }
        /// <summary>
        /// Method for displying values in the range slider
        /// </summary>
        public void PopulateScaleValues()
        {
            _sectionValue = Minimum;
            bool isDivFound = false;
            for (int i = MaximumInteraval; i >= MinimumInterval; i--)
            {
                if (!isDivFound)
                {
                    if (0 == Math.IEEERemainder(Maximum, i))
                    {
                        _interval = i;
                        isDivFound = true;
                        continue;
                    }
                }
            }
            _interval_width = Maximum / _interval;
            var totalSize = this.ActualWidth;
            Division = totalSize / _interval;
            this._scaleValueControl.Tag = Division;
            if (RangeCollection == null)
                RangeCollection = new List<Range>();
            RangeCollection.Add(new Range { RangeValue = _sectionValue });
            for (int i = 0; i < _interval; i++)
            {
                _sectionValue = _sectionValue + _interval_width;
                RangeCollection.Add(new Range { RangeValue = _sectionValue });
            }
            this._scaleValueControl.ItemsSource = RangeCollection;
            LastMark = (_sectionValue + _interval_width).ToString();
            this._lastmarkTextblock.Text = RangeCollection[_interval].RangeValue.ToString();
        }
        /// <summary>
        /// Called when size changed.
        /// </summary>
        private void SimpleSlider_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                //this.UpdateControls();
                //this.UpdateControls1();
                //PopulateScaleValues();
            }
        }
        /// <summary>
        /// Called when value changed.
        /// </summary>
        private static void OnValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            // Simple version: no coercion involved.
            var customSlider = (SimpleSlider)dependencyObject;
            if (IsThumb_Selected)
            {
                customSlider.UpperValue = Convert.ToDouble(e.NewValue);
            }
            else
            {
                customSlider.LowerValue = Convert.ToDouble(e.NewValue);
            }
        }
        /// <summary>
        /// Called  when lower value changed
        /// </summary>
        private static void LowerValuePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var customSlider = (SimpleSlider)dependencyObject;
            customSlider.UpperValue = Math.Max(customSlider.UpperValue, customSlider.LowerValue);
            customSlider.UpdateControls1();
        }
        /// <summary>
        /// Called When Upper value changed
        /// </summary>
        private static void UpperValuePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var customSlider = (SimpleSlider)dependencyObject;
            customSlider.LowerValue = Math.Min(customSlider.UpperValue, customSlider.LowerValue);
            customSlider.UpdateControls();
        }
        /// <summary>
        /// Handles the DragDelta event of the Thumb control.
        /// </summary>
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            IsThumbSelected = true;
            this._lowerthumb.Visibility = Visibility.Visible;
            this._upperThumb.Visibility = Visibility.Visible;
            var pixelDiff = e.HorizontalChange;
            var currentLeft = Canvas.GetLeft(this._upperThumb);
            // trying to drag too far left
            if ((currentLeft + pixelDiff) < 0)
            {
                this.UpperValue = 0;
            }
            // trying to drag too far right
            else if ((currentLeft + pixelDiff + this._upperThumb.ActualWidth) > this.ActualWidth)
            {
                this.UpperValue = this.Maximum;
            }
            else
            {
                var totalSize = this.ActualWidth;
                var ratioDiff = pixelDiff / totalSize;
                var rangeSize = this.Maximum - this.Minimum;
                var rangeDiff = rangeSize * ratioDiff;
                this.UpperValue += rangeDiff;
            }
            if (this.LowerValue == this.UpperValue && e.HorizontalChange < 0)
            {
                this._lowerthumb.Visibility = Visibility.Visible;
                this._upperThumb.Visibility = Visibility.Collapsed;
            }
            if (this.LowerValue == this.Minimum && this.LowerValue == this.UpperValue)
            {
                this._lowerthumb.Visibility = Visibility.Collapsed;
                this._upperThumb.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Handles the DragDelta event of the Thumb control.
        /// </summary>
        private void Thumb1_DragDelta(object sender, DragDeltaEventArgs e)
        {
            this._lowerthumb.Visibility = Visibility.Visible;
            this._upperThumb.Visibility = Visibility.Visible;
            IsThumbSelected = false;
            var pixelDiff = e.HorizontalChange;
            var currentLeft = Canvas.GetLeft(this._lowerthumb);
            // trying to drag too far left
            if ((currentLeft + pixelDiff) < 0)
            {
                this.LowerValue = 0;
            }
           
            // trying to drag too far right
            else if ((currentLeft + pixelDiff + this._lowerthumb.ActualWidth) > this.ActualWidth)
            {
                this.LowerValue = this.Maximum;
            }
            else
            {
                var totalSize = this.ActualWidth;
                var ratioDiff = pixelDiff / totalSize;
                var rangeSize = this.Maximum - this.Minimum;
                var rangeDiff = rangeSize * ratioDiff;
                this.LowerValue += rangeDiff;
            }
            if (this.LowerValue == this.UpperValue && e.HorizontalChange > 0)
            {
                this._lowerthumb.Visibility = Visibility.Collapsed;
                this._upperThumb.Visibility = Visibility.Visible;
            }
            if (this.LowerValue == this.Maximum && this.LowerValue==this.UpperValue)
            {
              
                this._lowerthumb.Visibility = Visibility.Visible;
                this._upperThumb.Visibility = Visibility.Collapsed;
            }
           
        }
        /// <summary>
        /// Updates the controls.
        /// </summary>
        public void UpdateControls()
        {
            double halfTheThumbWith = 0;
            if (this._upperThumb != null)
            {
                halfTheThumbWith = this._upperThumb.ActualWidth / 2;
            }
            double totalSize = this.ActualWidth - halfTheThumbWith * 2;
            double ratio = totalSize / (this.Maximum - this.Minimum);
            if (this._upperThumb != null)
            {
                Canvas.SetLeft(this._upperThumb, ratio * this.UpperValue);
            }
            if (this._middleFillRectangle != null)
            {
                Canvas.SetLeft(this._middleFillRectangle, ratio * this.LowerValue);
                this._middleFillRectangle.Width = ratio * (this.UpperValue - this.LowerValue) + halfTheThumbWith;
            }
        }
        /// <summary>
        /// Updates the controls.
        /// </summary>
        public void UpdateControls1()
        {
            double halfTheThumbWith = 0;
            if (this._lowerthumb != null)
            {
                halfTheThumbWith = this._upperThumb.ActualWidth / 2;
            }
            double totalSize = this.ActualWidth - halfTheThumbWith * 2;
            double ratio = totalSize / (this.Maximum - this.Minimum);
            if (this._lowerthumb != null)
            {
                Canvas.SetLeft(this._lowerthumb, ratio * this.LowerValue);
            }
            if (this._middleFillRectangle != null)
            {
                Canvas.SetLeft(this._middleFillRectangle, ratio * this.LowerValue);
                this._middleFillRectangle.Width = ratio * (this.UpperValue - this.LowerValue) + halfTheThumbWith;
            }
        }
    }
