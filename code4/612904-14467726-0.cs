    public static bool RangeIsContained(int outerMin, int outerMax, int innerMin, int innerMax)
    {
        return (outerMin <= innerMin && outerMax >= innerMax);
    }
    public bool IsContained(Itemi outer, Itemi inner)
    {
        return RangeIsContained(outer.Prop1Min, outer.Prop1Max, inner.Prop1Min, inner.Prop1Max)
            && RangeIsContained(outer.Prop2Min, outer.Prop2Max, inner.Prop2Min, inner.Prop2Max)
            // ...
            && RangeIsContained(outer.Prop25Min, outer.Prop25Max, inner.Prop25Min, inner.Prop25Max);
    }
