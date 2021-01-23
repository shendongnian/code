    public class RobusterProgressBar : ProgressBar
    {
        new public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register("Value", typeof(double), typeof(RobusterProgressBar), new PropertyMetadata(ValueChanged));
        new static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (RobusterProgressBar)d;
            control.Value = (double)e.NewValue;
        }
        new public static readonly DependencyProperty MaximumProperty = 
            DependencyProperty.Register("Maximum", typeof(double), typeof(RobusterProgressBar), new PropertyMetadata(MaximumChanged));
        static void MaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (RobusterProgressBar)d;
            control.Maximum = (double)e.NewValue;
        }
        private double _value;
        new public double Value
        {
            get { return _value; }
            set { 
                _value = value;
                // only update the reflected Value if it is valid
                if (_value <= _maximum)
                {
                    Update();
                }
            }
        }
        private double _maximum;
        new public double Maximum
        {
            get { return _maximum; }
            set { 
                _maximum = value;
                // only update the reflected maximum if it is valid
                if (_maximum >= _value)
                {
                    Update();
                }
            }
        }
        private void Update()
        {
            // set all of the ProgressBar values in the correct order so that the ProgressBar 
            // never breaks and stops rendering
            base.Value = 0; // assumes no negatives
            base.Maximum = _maximum;
            base.Value = _value;
        }
    }
