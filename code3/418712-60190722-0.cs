    public int GetValueNum(string name)
        {
            int _ret = 0;
            try
            {
                Control c = (extendedControls.Single(s => s.ValueName == name) as Control);
                if (c.GetType() == typeof(ExtendedNumericUpDown))
                    _ret = (int)((ExtendedNumericUpDown)c).Value;
                else
                    throw new Exception();
            }
            catch
            {
                throw new InvalidCastException(String.Format("Invalid cast fetching .Value value for {0}.\nExtendedControllerListener.GetValueNum()", name));
            }
            return _ret;
        }
