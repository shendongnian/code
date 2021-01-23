    public class EquatableList<T> : List<T>, IEquatable<EquatableList<T>> where    T : IEquatable<T>
    /// <summary>
    /// True, if this contains element with equal property-values
    /// </summary>
    /// <param name="element">element of Type T</param>
    /// <returns>True, if this contains element</returns>
    public new Boolean Contains(T element)
    {
        return this.Any(t => t.Equals(element));
    }
    /// <summary>
    /// True, if list is equal to this
    /// </summary>
    /// <param name="list">list</param>
    /// <returns>True, if instance equals list</returns>
    public Boolean Equals(EquatableList<T> list)
    {
        if (list == null) return false;
        return this.All(list.Contains) && list.All(this.Contains);
    }
