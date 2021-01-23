    public partial class MyFovControl : UserControl
    {
    private float m_oldAngleValue;
    private float m_newAngleValue;
    public MyFovControl()
    {
      InitializeComponent();
      this.zoomSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(zoomSlider_ValueChanged);
      m_oldAngleValue = m_newAngleValue = 0;
    }
    void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      m_newAngleValue = (float)(Convert.ToDouble((double)lblFovXAngle.Content));
      // Happens only once the first time.
      if (m_oldAngleValue == 0)
      {
        m_oldAngleValue = m_newAngleValue;
      }
      m_leftLine.Point = new Point(m_leftLine.Point.X + (m_oldAngleValue - m_newAngleValue), m_leftLine.Point.Y);
      m_rightLine.Point = new Point(m_rightLine.Point.X - (m_oldAngleValue - m_newAngleValue), m_rightLine.Point.Y);
      m_oldAngleValue = m_newAngleValue;
      }
    }
