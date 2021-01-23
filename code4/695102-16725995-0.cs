    using System.Runtime.InteropServices;
    ...
    [StructLayout(LayoutKind.Explicit)]
    struct X86Register {
       [FieldOffset(0)] public byte   reg8;    // Like AL
       [FieldOffset(1)] public byte   reg8h;   // Like AH
       [FieldOffset(0)] public ushort reg16;   // Like AX
       [FieldOffset(0)] public uint   reg32;   // Like EAX
       [FieldOffset(0)] public ulong  reg64;   // Like RAX
    }
