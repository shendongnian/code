    private PointF[] CreateBaseSignal(SignalType signalType)
    {
      switch (signalType)
      {
        case SignalType.Sine:
          const int oversampling = 32;
          PointF[] signal = new PointF[oversampling];
          for (int i = 0; i < signal.Length; i++)
          {
            signal[i].X = (float) i / oversampling;
            signal[i].Y = Convert.ToSingle(Math.Sin((double) i / oversampling * 2 * Math.PI));
          }
          return signal;
        case SignalType.Square:
          return new PointF[]
          {
            new PointF(0.0f, -1.0f),
            new PointF(0.5f, -1.0f),
            new PointF(0.5f, 1.0f),
            new PointF(1.0f, 1.0f),
          };
        case SignalType.Triangle:
          return new PointF[]
          {
            new PointF(0.0f, -1.0f),
            new PointF(0.5f, 1.0f),
          };
        case SignalType.Sawtooth:
          return new PointF[]
          {
            new PointF(0.0f, -1.0f),
            new PointF(1.0f, 1.0f),
          };
        default:
          throw new ArgumentException("Invalid signal type", "signalType");
      }
    }
