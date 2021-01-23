    interface IMyControl<A, B> { }
    public partial abstract class MyControlBase<A, B> : DataGridView, IMyControl<A, B>
    {
        // Generic code goes here
    }
    // Create non-generic wrappers for the generic base class
    public partial class MyControl_One : DataGridView, MyControlBase<SomeType, OtherType>
    {
         // Type-specific (if any) code goes here
    }
    public partial class MyControl_Two : DataGridView, MyControlBase<MyType, YourType>
    {
         // Type-specific (if any) code goes here
    }
