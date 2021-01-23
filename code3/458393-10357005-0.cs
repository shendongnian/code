        using System;
        using System.Collections.Generic;
	// Class that implements a ProjectionComparer for any type that projects the type to another type (usually a key field).
	public sealed class ProjectionComparer<TCompare, TProjected> : EqualityComparer<TCompare>, IComparer<TCompare>
	{
		private readonly Func<TCompare, TProjected> _projection;
		// Initialize a new instance of the GenericEqualityComparer class
		public ProjectionComparer(Func<TCompare, TProjected> projection)
		{
			if (projection == null)
			{
				throw new ArgumentNullException("projection");
			}
			_projection = projection;
		}
		// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		public int Compare(TCompare left, TCompare right)
		{
			// if both same object or both null, return zero automatically
			if (ReferenceEquals(left, right))
			{
				return 0;
			}
			// can only happen if left null and right not null
			if (left == null)
			{
				return -1;
			}
			// can only happen if right null and left non-null
			if (right == null)
			{
				return 1;
			}
			// otherwise compare the projections
			return Comparer<TProjected>.Default.Compare(_projection(left), _projection(right));
		}
		// Template equals method that calls the comparison function
		public override bool Equals(TCompare left, TCompare right)
		{
			// why bother to extract if they refer to same object...
			if (ReferenceEquals(left, right))
			{
				return true;
			}
			// if either is null, no sense checking either (both are null is handled by ReferenceEquals())
			if (left == null || right == null)
			{
				return false;
			}
			return Equals(_projection(left), _projection(right));
		}
		// Template GetHashCode method that calls the comparison function
		public override int GetHashCode(TCompare obj)
		{
			// unlike Equals, GetHashCode() should never be called on a null object
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			var key = _projection(obj);
			// I decided since obj is non-null, i'd return zero if key was null.
			return key == null ? 0 : key.GetHashCode();
		}
		// Factory method to generate the comparer for the projection using type inference.
		public static ProjectionComparer<TCompare, TProjected> Create<TCompare, TProjected>(Func<TCompare, TProjected> projection)
		{
			return new ProjectionComparer<TCompare, TProjected>(projection);
		}
	}
