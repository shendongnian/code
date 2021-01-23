    #region + Using Directives
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using TestEnum;
    
    #endregion
    
    namespace TestEnum
    {
    	public abstract class ACsEnum<T, U, V> :
    		IComparable<ACsEnum<T, U, V>>
    		where T : ACsEnum<T, U, V>
    	{
    		static ACsEnum()
    		{
    			// the static constructor causes
    			// early creation of the object
    			Count = 0;
    		}
    
    		// constructor
    		protected ACsEnum(Enum m, V v)
    		{
    			Enum = m;
    			Value = v;
    			Ordinal = Count++;
    		}
    
    	#region Admin Private fields
    
    		// the list of members
    		protected static readonly List<T> members = new List<T>();
    
    	#endregion
    
    	#region Admin Public Properties
    
    		// the enum associated with this class
    		public Enum Enum { get; }
    
    		// number of members
    		public static int Count { get; private set; }
    
    		// ordinal number of this member (zero based)
    		public int Ordinal { get; }
    
    		// a name of this member
    		public string Name => ToString();
    
    		// the value attached to the enum
    		public U Amount => (U) (IConvertible) Enum;
    
    		// the value of this member - this value is
    		// returned from the implicit conversion
    		public V Value { get; }
    
    	#endregion
    
    	#region Admin Operator
    
    		public static implicit operator V (ACsEnum<T, U, V> m)
    		{
    			return m.Value;
    		}
    
    	#endregion
    
    	#region Admin Functions
    
    		// compare
    		public int CompareTo(ACsEnum<T, U, V> other)
    		{
    			if (other.GetType() != typeof(T)) { return -1; }
    
    			return Ordinal.CompareTo(other.Ordinal);
    		}
    
    		// determine if the name provided is a member
    		public static bool IsMember(string name, bool caseSensitive)
    		{
    			return Find(name, caseSensitive) != null;
    		}
    
    		// finds and returns a member
    		public static T Find (string name, bool caseSensitive = false)
    		{
    			if (caseSensitive)
    			{
    				return members.Find(s => s.ToString().Equals(name));
    			}
    			else
    			{
    				return members.Find(s => s.ToString().ToLower().Equals(name.ToLower()));
    			}
    		}
    
    		// allow enumeration over the members
    		public static IEnumerable Members()
    		{
    			foreach (T m in members)
    			{
    				yield return m;
    			}
    		}
    
    		// get the members as an array
    		public static T[] Values()
    		{
    			return members.ToArray();
    		}
    
    		// same as Find but throws an exception 
    		public static T ValueOf(string name)
    		{
    			T m = Find(name, true);
    
    			if (m != null) return m;
    
    			throw new InvalidEnumArgumentException();
    		}
    
    	#endregion
    
    	#region Admin Overrides
    
    		public override bool Equals(object obj)
    		{
    			if (obj != null && obj.GetType() != typeof(T)) return false;
    
    			return ((T) obj).Ordinal == Ordinal ;
    		}
    
    	#endregion
    	}
    }
