    private static void Normalize<T>(List<T> elements, Func<T, double> getter, Action<T, double> setter)
    {
        double fMin = elements.Min(getter);
        double fMax = elements.Max(getter);
        double fDelta = fMax - fMin;
        double fInv = 1.0d / fDelta;
        for (int i = 0; i < elements.Count; i++)
        {
            T t = elements[i];
    		
    		double initialValue = getter(t);
    		double newValue = (initialValue - fMin) * fInv;
    		setter(t, newValue);
        }
    }
