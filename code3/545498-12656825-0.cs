	using System;
	using System.Collections;
	using System.Linq;
	using System.Text;
	using System.Diagnostics;
	using System.Runtime.InteropServices;
	namespace dummy
	{
		class Program
		{
			static bool EnumSymProc(ref DbgHelp.SYMBOL_INFO pSymInfo,
				UInt32 SymbolSize,
				IntPtr UserContext)
			{
				Console.WriteLine(pSymInfo.Address + " " + SymbolSize + " " + pSymInfo.Name);
				return true;
			}
			static void Main(string[] args)
			{
				Process process = Process.GetCurrentProcess();
				ulong BaseOfDll;
				string Mask = "*";
				bool status;
				status = DbgHelp.SymInitialize(process.Handle, null, false);
				if (status == false)
				{
					return;
				}
				BaseOfDll = DbgHelp.SymLoadModuleEx(process.Handle,
											IntPtr.Zero,
											"dummy3.dll",
											null,
											IntPtr.Zero,
											0,
											IntPtr.Zero,
											0);
				if (BaseOfDll == 0)
				{
					DbgHelp.SymCleanup(process.Handle);
					return;
				}
				if (DbgHelp.SymEnumSymbols(process.Handle,     // Process handle from SymInitialize.
									BaseOfDll,   // Base address of module.
									Mask,        // Name of symbols to match.
									new DbgHelp.SymEnumSymbolsProc(EnumSymProc), // Symbol handler procedure.
									IntPtr.Zero))       // User context.
				{
					// SymEnumSymbols succeeded
				}
				else
				{
					// SymEnumSymbols failed
					Console.WriteLine("SymEnumSymbols failed: " + Marshal.GetLastWin32Error());
				}
				DbgHelp.SymCleanup(process.Handle);
			}
		}
		public static class DbgHelp
		{
			[Flags]
			public enum SymOpt : uint
			{
				CASE_INSENSITIVE = 0x00000001,
				UNDNAME = 0x00000002,
				DEFERRED_LOADS = 0x00000004,
				NO_CPP = 0x00000008,
				LOAD_LINES = 0x00000010,
				OMAP_FIND_NEAREST = 0x00000020,
				LOAD_ANYTHING = 0x00000040,
				IGNORE_CVREC = 0x00000080,
				NO_UNQUALIFIED_LOADS = 0x00000100,
				FAIL_CRITICAL_ERRORS = 0x00000200,
				EXACT_SYMBOLS = 0x00000400,
				ALLOW_ABSOLUTE_SYMBOLS = 0x00000800,
				IGNORE_NT_SYMPATH = 0x00001000,
				INCLUDE_32BIT_MODULES = 0x00002000,
				PUBLICS_ONLY = 0x00004000,
				NO_PUBLICS = 0x00008000,
				AUTO_PUBLICS = 0x00010000,
				NO_IMAGE_SEARCH = 0x00020000,
				SECURE = 0x00040000,
				SYMOPT_DEBUG = 0x80000000
			};
			[Flags]
			public enum SymFlag : uint
			{
				VALUEPRESENT = 0x00000001,
				REGISTER = 0x00000008,
				REGREL = 0x00000010,
				FRAMEREL = 0x00000020,
				PARAMETER = 0x00000040,
				LOCAL = 0x00000080,
				CONSTANT = 0x00000100,
				EXPORT = 0x00000200,
				FORWARDER = 0x00000400,
				FUNCTION = 0x00000800,
				VIRTUAL = 0x00001000,
				THUNK = 0x00002000,
				TLSREL = 0x00004000,
			}
			[Flags]
			public enum SymTagEnum : uint
			{
				Null,
				Exe,
				Compiland,
				CompilandDetails,
				CompilandEnv,
				Function,
				Block,
				Data,
				Annotation,
				Label,
				PublicSymbol,
				UDT,
				Enum,
				FunctionType,
				PointerType,
				ArrayType,
				BaseType,
				Typedef,
				BaseClass,
				Friend,
				FunctionArgType,
				FuncDebugStart,
				FuncDebugEnd,
				UsingNamespace,
				VTableShape,
				VTable,
				Custom,
				Thunk,
				CustomType,
				ManagedType,
				Dimension
			};
			[Flags]
			public enum SymType : uint
			{
				SymNone,
				SymCoff,
				SymCv,
				SymPdb,
				SymExport,
				SymDeferred,
				SymSym,
				SymDia,
				SymVirtual,
			}
			[StructLayout(LayoutKind.Sequential)]
			public struct SYMBOL_INFO
			{
				public uint SizeOfStruct;
				public uint TypeIndex;
				public ulong Reserved1;
				public ulong Reserved2;
				public uint Reserved3;
				public uint Size;
				public ulong ModBase;
				public SymFlag Flags;
				public ulong Value;
				public ulong Address;
				public uint Register;
				public uint Scope;
				public SymTagEnum Tag;
				public int NameLen;
				public int MaxNameLen;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
				public string Name;
			};
			[StructLayout(LayoutKind.Sequential)]
			public struct MODLOAD_DATA
			{
				UInt32 ssize;
				UInt32 ssig;
				object data;
				UInt32 size;
				UInt32 flags;
			}
			[StructLayout(LayoutKind.Sequential)]
			public struct _IMAGEHLP_LINE64
			{
				public uint SizeOfStruct;
				public uint Key;
				public uint LineNumber;
				public IntPtr FileName;
				public ulong Address;
			};
			[StructLayout(LayoutKind.Sequential)]
			public struct IMAGEHLP_MODULE64
			{
				public uint SizeOfStruct;
				public ulong BaseOfImage;
				public uint ImageSize;
				public uint TimeDateStamp;
				public uint CheckSum;
				public uint NumSyms;
				public SymType SymType;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
				public string ModuleName;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
				public string ImageName;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
				public string LoadedImageName;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
				public string LoadedPdbName;
				public uint CVSig;
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 780)]
				public string CVData;
				public uint PdbSig;
				public Guid PdbSig70;
				public uint PdbAge;
				public bool PdbUnmatched;
				public bool DbgUnmatched;
				public bool LineNumbers;
				public bool GlobalSymbols;
				public bool TypeInfo;
				public bool SourceIndexed;
				public bool Publics;
			}
			public delegate bool SymEnumSymbolsProc(ref SYMBOL_INFO pSymInfo, uint SymbolSize, IntPtr UserContext);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymInitialize(IntPtr hProcess, string UserSearchPath, bool fInvadeProcess);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern uint SymSetOptions(SymOpt SymOptions);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern ulong SymLoadModule64(IntPtr hProcess, IntPtr hFile,
			   string ImageName, string ModuleName,
			   ulong BaseOfDll, uint SizeOfDll);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern ulong SymLoadModuleEx(IntPtr hProcess, IntPtr hFile,
				string ImageName, string ModuleName, IntPtr BaseOfDll,
				UInt32 DllSize, ref MODLOAD_DATA Data, UInt32 Flags);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern ulong SymLoadModuleEx(IntPtr hProcess, IntPtr hFile,
				string ImageName, string ModuleName, IntPtr BaseOfDll,
				UInt32 DllSize, IntPtr Data, UInt32 Flags);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymGetModuleInfo64(IntPtr hProcess, ulong dwAddress, ref IMAGEHLP_MODULE64 ModuleInfo);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymEnumSymbols(IntPtr hProcess, ulong BaseOfDll, string Mask, SymEnumSymbolsProc EnumSymbolsCallback, IntPtr UserContext);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymGetLineFromAddr64(IntPtr hProcess,
			   ulong dwAddr, ref uint pdwDisplacement, ref _IMAGEHLP_LINE64 Line);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymFromAddr(IntPtr hProcess,
			   ulong dwAddr, ref ulong pdwDisplacement, ref SYMBOL_INFO symbolInfo);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymEnumSymbolsForAddr(IntPtr hProcess,
			   ulong Address, SymEnumSymbolsProc EnumSymbolsCallback, IntPtr UserContext);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymUnloadModule64(IntPtr hProcess, ulong BaseOfDll);
			[DllImport("dbghelp.dll", SetLastError = true)]
			public static extern bool SymCleanup(IntPtr hProcess);
		}
	}
