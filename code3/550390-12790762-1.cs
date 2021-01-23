    interface IMyControl<A, B> { }
    public partial abstract class MyControlBase<A, B> : DataGridView, IMyControl<A, B>
    {
    }
    // Create non-generic wrappers for the generic base class
    public partial class MyControl_One : DataGridView, MyControlBase<SomeType, OtherType>
    {
    }
    public partial class MyControl_Two : DataGridView, MyControlBase<MyType, YourType>
    {
    }
