        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Linq;
        using System.Runtime.InteropServices;
        using System.Text;
    
        namespace DXCutcsa.VO.Common
        {
        	public class SmartCardReader
        	{
        		#region Atributos
    
    		private bool _disposed = false;
    		private IntPtr _ReaderContext = IntPtr.Zero;
    		private string _ReaderName = string.Empty;
    		private List<string> _AvailableReaders = new List<string>();
    
    		#endregion
    
    		#region Win32 APIs
    
    		[DllImport("WinScard.dll")]
    		static extern int SCardEstablishContext(uint dwScope,
    			IntPtr notUsed1,
    			IntPtr notUsed2,
    			out IntPtr phContext);
    
    		[DllImport("WinScard.dll")]
    		static extern int SCardReleaseContext(IntPtr phContext);
    
    		[DllImport("WinScard.dll")]
    		static extern int SCardConnect(IntPtr hContext,
    			string cReaderName,
    			uint dwShareMode,
    			uint dwPrefProtocol,
    			ref IntPtr phCard,
    			ref IntPtr ActiveProtocol);
    
    		[DllImport("WinScard.dll")]
    		static extern int SCardDisconnect(IntPtr hCard, int Disposition);
    
    		[DllImport("WinScard.dll", EntryPoint = "SCardListReadersA", CharSet = CharSet.Ansi)]
    		static extern int SCardListReaders(
    			IntPtr hContext,
    			byte[] mszGroups,
    			byte[] mszReaders,
    			ref UInt32 pcchReaders);
    
    		[DllImport("winscard.dll")]
    		static extern int SCardStatus(
    			   uint hCard,
    			   IntPtr szReaderName,
    			   ref int pcchReaderLen,
    			   ref int pdwState,
    			   ref uint pdwProtocol,
    			   byte[] pbAtr,
    			   ref int pcbAtrLen);
    
    		[DllImport("winscard.dll")]
    		static extern int SCardTransmit(
    			IntPtr hCard,
    			ref SCARD_IO_REQUEST pioSendRequest,
    			ref byte SendBuff,
    			uint SendBuffLen,
    			ref SCARD_IO_REQUEST pioRecvRequest,
    			byte[] RecvBuff,
    			ref uint RecvBuffLen);
    
    		[DllImport("winscard.dll", SetLastError = true)]
    		static extern int SCardGetAttrib(
    		   IntPtr hCard,            // Valor retornado en funcion ScardConnect
    		   UInt32 dwAttrId,         // Identificacion de atributos a obtener
    		   byte[] pbAttr,           // Puntero al vector atributos recividos 
    		   ref IntPtr pcbAttrLen    // Tamaño del vector
    		);
    
    		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    		public struct ReaderState
    		{
    			public ReaderState(string sName)
    			{
    				this.szReader = sName;
    				this.pvUserData = IntPtr.Zero;
    				this.dwCurrentState = 0;
    				this.dwEventState = 0;
    				this.cbATR = 0;
    				this.rgbATR = null;
    			}
    
    			internal string szReader;
    			internal IntPtr pvUserData;
    			internal uint dwCurrentState;
    			internal uint dwEventState;
    			internal uint cbATR;    // count of bytes in rgbATR
    			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x24, ArraySubType = UnmanagedType.U1)]
    			internal byte[] rgbATR;
    		}
    
    		[StructLayout(LayoutKind.Sequential)]
    		public struct SCARD_IO_REQUEST
    		{
    			public UInt32 dwProtocol;
    			public UInt32 cbPciLength;
    		}
    
    
    		/*****************************************************************/
    		[DllImport("kernel32.dll", SetLastError = true)]
    		private extern static IntPtr LoadLibrary(string lpFileName);
    
    		[DllImport("kernel32.dll")]
    		private extern static void FreeLibrary(IntPtr handle);
    
    		[DllImport("kernel32.dll")]
    		private extern static IntPtr GetProcAddress(IntPtr handle, string procName);
    
    		#endregion
    
    		#region Error codes
    		public const uint S_SUCCESS = 0x00000000;
    		public const uint F_INTERNAL_ERROR = 0x80100001;
    		public const uint E_CANCELLED = 0x80100002;
    		public const uint E_INVALID_HANDLE = 0x80100003;
    		public const uint E_INVALID_PARAMETER = 0x80100004;
    		public const uint E_INVALID_TARGET = 0x80100005;
    		public const uint E_NO_MEMORY = 0x80100006;
    		public const uint F_WAITED_TOO_LONG = 0x80100007;
    		public const uint E_INSUFFICIENT_BUFFER = 0x80100008;
    		public const uint E_UNKNOWN_READER = 0x80100009;
    		public const uint E_TIMEOUT = 0x8010000A;
    		public const uint E_SHARING_VIOLATION = 0x8010000B;
    		public const uint E_NO_SMARTCARD = 0x8010000C;
    		public const uint E_UNKNOWN_CARD = 0x8010000D;
    		public const uint E_CANT_DISPOSE = 0x8010000E;
    		public const uint E_PROTO_MISMATCH = 0x8010000F;
    		public const uint E_NOT_READY = 0x80100010;
    		public const uint E_INVALID_VALUE = 0x80100011;
    		public const uint E_SYSTEM_CANCELLED = 0x80100012;
    		public const uint F_COMM_ERROR = 0x80100013;
    		public const uint F_UNKNOWN_ERROR = 0x80100014;
    		public const uint E_INVALID_ATR = 0x80100015;
    		public const uint E_NOT_TRANSACTED = 0x80100016;
    		public const uint E_READER_UNAVAILABLE = 0x80100017;
    		public const uint P_SHUTDOWN = 0x80100018;
    		public const uint E_PCI_TOO_SMALL = 0x80100019;
    		public const uint E_READER_UNSUPPORTED = 0x8010001A;
    		public const uint E_DUPLICATE_READER = 0x8010001B;
    		public const uint E_CARD_UNSUPPORTED = 0x8010001C;
    		public const uint E_NO_SERVICE = 0x8010001D;
    		public const uint E_SERVICE_STOPPED = 0x8010001E;
    		public const uint E_UNEXPECTED = 0x8010001F;
    		public const uint E_ICC_INSTALLATION = 0x80100020;
    		public const uint E_ICC_CREATEORDER = 0x80100021;
    		public const uint E_UNSUPPORTED_FEATURE = 0x80100022;
    		public const uint E_DIR_NOT_FOUND = 0x80100023;
    		public const uint E_FILE_NOT_FOUND = 0x80100024;
    		public const uint E_NO_DIR = 0x80100025;
    		public const uint E_NO_FILE = 0x80100026;
    		public const uint E_NO_ACCESS = 0x80100027;
    		public const uint E_WRITE_TOO_MANY = 0x80100028;
    		public const uint E_BAD_SEEK = 0x80100029;
    		public const uint E_INVALID_CHV = 0x8010002A;
    		public const uint E_UNKNOWN_RES_MNG = 0x8010002B;
    		public const uint E_NO_SUCH_CERTIFICATE = 0x8010002C;
    		public const uint E_CERTIFICATE_UNAVAILABLE = 0x8010002D;
    		public const uint E_NO_READERS_AVAILABLE = 0x8010002E;
    		public const uint E_COMM_DATA_LOST = 0x8010002F;
    		public const uint E_NO_KEY_CONTAINER = 0x80100030;
    		public const uint W_UNSUPPORTED_CARD = 0x80100065;
    		public const uint W_UNRESPONSIVE_CARD = 0x80100066;
    		public const uint W_UNPOWERED_CARD = 0x80100067;
    		public const uint W_RESET_CARD = 0x80100068;
    		public const uint W_REMOVED_CARD = 0x80100069;
    		public const uint W_SECURITY_VIOLATION = 0x8010006A;
    		public const uint W_WRONG_CHV = 0x8010006B;
    		public const uint W_CHV_BLOCKED = 0x8010006C;
    		public const uint W_EOF = 0x8010006D;
    		public const uint W_CANCELLED_BY_USER = 0x8010006E;
    		public const uint W_CARD_NOT_AUTHENTICATED = 0x8010006F;
    		#endregion
    
    		#region Constructor
    
    		public SmartCardReader()
    		{
    
    		}
    		#endregion
    
    		#region Metodos
    
    		public long GetUID(ref byte[] UID)
    		{
    			long _result = 0;
    			bool cardInserted = false;
    
    
    			IntPtr _CardContext = IntPtr.Zero;
    			IntPtr ActiveProtocol = IntPtr.Zero;
    
    			// Establish Reader context:
    			if (this._ReaderContext == IntPtr.Zero)
    			{
    				_result = SCardEstablishContext(2, IntPtr.Zero, IntPtr.Zero, out this._ReaderContext);
    
    				#region Get List of Available Readers
    
    				uint pcchReaders = 0;
    				int nullindex = -1;
    				char nullchar = (char)0;
    
    				// First call with 3rd parameter set to null gets readers buffer length.
    				_result = SCardListReaders(this._ReaderContext, null, null, ref pcchReaders);
    
    				byte[] mszReaders = new byte[pcchReaders];
    
    				// Fill readers buffer with second call.
    				_result = SCardListReaders(this._ReaderContext, null, mszReaders, ref pcchReaders);
    
    				// Populate List with readers.
    				string currbuff = new ASCIIEncoding().GetString(mszReaders);
    				int len = (int)pcchReaders;
    
    				if (len > 0)
    				{
    					while (currbuff[0] != nullchar)
    					{
    						nullindex = currbuff.IndexOf(nullchar);   // Get null end character.
    						string reader = currbuff.Substring(0, nullindex);
    						this._AvailableReaders.Add(reader);
    						len = len - (reader.Length + 1);
    						currbuff = currbuff.Substring(nullindex + 1, len);
    					}
    				}
    
    				#endregion
    
    				// Select the first reader:
    				this._ReaderName = this._AvailableReaders[0];
    			}
    
    			try
    			{
    				//Check if there is a Card in the reader:
    
    				//dwShareMode: SCARD_SHARE_SHARED = 0x00000002 - This application will allow others to share the reader
    				//dwPreferredProtocols: SCARD_PROTOCOL_T0 - Use the T=0 protocol (value = 0x00000001)
    
    				if (this._ReaderContext != IntPtr.Zero)
    				{
    					_result = SCardConnect(this._ReaderContext, this._ReaderName, 0x00000002, 0x00000001, ref _CardContext, ref ActiveProtocol);
    					if (_result == 0)
    					{
    						cardInserted = true;
    
    						SCARD_IO_REQUEST request = new SCARD_IO_REQUEST()
    						{
    							dwProtocol = (uint)ActiveProtocol,
    							cbPciLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(SCARD_IO_REQUEST))
    						};
    
    						byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x00 }; //<- get UID command for iClass cards
    						byte[] ret_Bytes = new byte[33];
    						uint sendLen = (uint)sendBytes.Length;
    						uint ret_Len = (uint)ret_Bytes.Length;
    
    						_result = SCardTransmit(_CardContext, ref request, ref sendBytes[0], sendLen, ref request, ret_Bytes, ref ret_Len);
    						if (_result == 0)
    						{
    							UID = ret_Bytes.Take(4).ToArray(); //only take the first 8, the last 2 bytes are not part of the UID of the card 														   
    							string dataOut = byteToHexa(UID, UID.Length, true).Trim(); //Devolver la respuesta en Hexadecimal
    						}
    					}
    				}
    			}
    			finally
    			{
    				SCardDisconnect(_CardContext, 0);
    				SCardReleaseContext(this._ReaderContext);
    			}
    			return _result;
    		}
    
    
    		private string byteToHexa(byte[] byReadBuffer, int leng, bool bSpace)
    		{
    			string text2 = "";
    			for (short num1 = 0; num1 < leng; num1 = (short)(num1 + 1))
    			{
    				short num2 = byReadBuffer[num1];
    
    				text2 = text2 + System.Convert.ToString(num2, 16).PadLeft(2, '0');
    
    				if (bSpace)
    				{
    					text2 = text2 + " ";
    				}
    			}
    			return text2.ToUpper();
    		}
    
    
    		//Get the address of Pci from "Winscard.dll".
    		private IntPtr GetPciT0()
    		{
    			IntPtr handle = LoadLibrary("Winscard.dll");
    			IntPtr pci = GetProcAddress(handle, "g_rgSCardT0Pci");
    			FreeLibrary(handle);
    			return pci;
    		}
    
    		#endregion
    
    
    	}// Fin de la Clase
        }
