But you may get closer to what you'd like by changing your approach.  What if you used a non-generic IHierarchy?  (also correct the spelling)  If...
    public inetrface IHierarchy : IHierarchyItem
    {
        IHierarchy Parent { get; set; }
        IList<IHierarchy> Children { get; set; }
    }
...then any IHierarchy node variable could access node.Parent and node.Children... and also node.Id and node.Title because the IHierarchyItem is required and thus is known to IHierarchy.
This approach would handle the hierarchy aspects easily and allows polymorphism in your WorkContext.Current (etc) return values, but it would require explicit casting from there to access anything specific to a class outside of the defined members of IHierarchy.  It's not clear how much of an issue that might be for your purpose.
You could also perhaps layer a generic IHierarchy&lt;T&gt; : IHierarchy on top of it to allow handling by a specific type without further casting.  You might have to define one or both interface members explicitly rather than implicitly (in implementing classes) to avoid name collisions on the properties without generic type arguments.
