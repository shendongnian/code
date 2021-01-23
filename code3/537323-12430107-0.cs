     public void Select(uint target)
            {
                fixed (void* pThis = &this)
                {
                    Generic.Invoke<Action<uint, uint>>(this.VTable[0xC0], CallingConvention.ThisCall)
                        ((uint)pThis, target);
                }
            }
    
            [FieldOffset(0x00)]
            public uint* VTable;
