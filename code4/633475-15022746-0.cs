    // Type: System.IntPtr
    // Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    // Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
    
    using System.Globalization;
    using System.Runtime;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security;
    
    namespace System
    {
      [ComVisible(true)]
      [__DynamicallyInvokable]
      [Serializable]
      public struct IntPtr : ISerializable
      {
        [SecurityCritical]
        private unsafe void* m_value;
        public static readonly IntPtr Zero;
    
        [__DynamicallyInvokable]
        public static int Size
        {
          [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get
          {
            return 4;
          }
        }
    
        [SecuritySafeCritical]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [__DynamicallyInvokable]
        public IntPtr(int value)
        {
          this.m_value = (void*) value;
        }
    
        [SecuritySafeCritical]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [__DynamicallyInvokable]
        public IntPtr(long value)
        {
          this.m_value = (void*) checked ((int) value);
        }
    
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [SecurityCritical]
        [CLSCompliant(false)]
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public IntPtr(void* value)
        {
          this.m_value = value;
        }
    
        [SecurityCritical]
        private IntPtr(SerializationInfo info, StreamingContext context)
        {
          long int64 = info.GetInt64("value");
          if (IntPtr.Size == 4 && (int64 > (long) int.MaxValue || int64 < (long) int.MinValue))
            throw new ArgumentException(Environment.GetResourceString("Serialization_InvalidPtrValue"));
          this.m_value = (void*) int64;
        }
    
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static explicit operator IntPtr(int value)
        {
          return new IntPtr(value);
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        public static explicit operator IntPtr(long value)
        {
          return new IntPtr(value);
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [SecurityCritical]
        [CLSCompliant(false)]
        public static explicit operator IntPtr(void* value)
        {
          return new IntPtr(value);
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        [CLSCompliant(false)]
        public static explicit operator void*(IntPtr value)
        {
          return value.ToPointer();
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        public static explicit operator int(IntPtr value)
        {
          return (int) value.m_value;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        public static explicit operator long(IntPtr value)
        {
          return (long) (int) value.m_value;
        }
    
        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static bool operator ==(IntPtr value1, IntPtr value2)
        {
          return value1.m_value == value2.m_value;
        }
    
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        public static bool operator !=(IntPtr value1, IntPtr value2)
        {
          return value1.m_value != value2.m_value;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        public static IntPtr operator +(IntPtr pointer, int offset)
        {
          return new IntPtr(pointer.ToInt32() + offset);
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        public static IntPtr operator -(IntPtr pointer, int offset)
        {
          return new IntPtr(pointer.ToInt32() - offset);
        }
    
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SecuritySafeCritical]
        internal unsafe bool IsNull()
        {
          return (IntPtr) this.m_value == IntPtr.Zero;
        }
    
        [SecurityCritical]
        unsafe void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
          if (info == null)
            throw new ArgumentNullException("info");
          info.AddValue("value", (long) (int) this.m_value);
        }
    
        [SecuritySafeCritical]
        [__DynamicallyInvokable]
        public override unsafe bool Equals(object obj)
        {
          if (obj is IntPtr)
            return this.m_value == ((IntPtr) obj).m_value;
          else
            return false;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        [__DynamicallyInvokable]
        public override unsafe int GetHashCode()
        {
          return (int) this.m_value;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [__DynamicallyInvokable]
        public unsafe int ToInt32()
        {
          return (int) this.m_value;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [SecuritySafeCritical]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [__DynamicallyInvokable]
        public unsafe long ToInt64()
        {
          return (long) (int) this.m_value;
        }
    
        [SecuritySafeCritical]
        [__DynamicallyInvokable]
        public override unsafe string ToString()
        {
          return ((int) this.m_value).ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
    
        [SecuritySafeCritical]
        [__DynamicallyInvokable]
        public unsafe string ToString(string format)
        {
          return ((int) this.m_value).ToString(format, (IFormatProvider) CultureInfo.InvariantCulture);
        }
    
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public static IntPtr Add(IntPtr pointer, int offset)
        {
          return pointer + offset;
        }
    
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
        public static IntPtr Subtract(IntPtr pointer, int offset)
        {
          return pointer - offset;
        }
    
        [SecuritySafeCritical]
        [CLSCompliant(false)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public unsafe void* ToPointer()
        {
          return this.m_value;
        }
      }
    }
