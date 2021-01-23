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
    					szReader = sName;
    					pvUserData = IntPtr.Zero;
    					dwCurrentState = 0;
    					dwEventState = 0;
    					cbATR = 0;
    					rgbATR = null;
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
    				if (_ReaderContext == IntPtr.Zero)
    				{
    					_result = SCardEstablishContext(2, IntPtr.Zero, IntPtr.Zero, out _ReaderContext);
    
    					#region Get List of Available Readers
    
    					uint pcchReaders = 0;
    					int nullindex = -1;
    					char nullchar = (char)0;
    
    					// First call with 3rd parameter set to null gets readers buffer length.
    					_result = SCardListReaders(_ReaderContext, null, null, ref pcchReaders);
    
    					byte[] mszReaders = new byte[pcchReaders];
    
    					// Fill readers buffer with second call.
    					_result = SCardListReaders(_ReaderContext, null, mszReaders, ref pcchReaders);
    
    					// Populate List with readers.
    					string currbuff = new ASCIIEncoding().GetString(mszReaders);
    					int len = (int)pcchReaders;
    
    					if (len > 0)
    					{
    						while (currbuff[0] != nullchar)
    						{
    							nullindex = currbuff.IndexOf(nullchar);   // Get null end character.
    							string reader = currbuff.Substring(0, nullindex);
    							_AvailableReaders.Add(reader);
    							len = len - (reader.Length + 1);
    							currbuff = currbuff.Substring(nullindex + 1, len);
    						}
    					}
    
    					#endregion
    
    					// Select the first reader:
    					_ReaderName = _AvailableReaders[0];
    				}			
    
    				try
    				{
    					//Check if there is a Card in the reader:
    
    					//dwShareMode: SCARD_SHARE_SHARED = 0x00000002 - This application will allow others to share the reader
    					//dwPreferredProtocols: SCARD_PROTOCOL_T0 - Use the T=0 protocol (value = 0x00000001)
    
    					if (_ReaderContext != IntPtr.Zero)
    					{
    						_result = SCardConnect(_ReaderContext, _ReaderName, 0x00000002, 0x00000001, ref _CardContext, ref ActiveProtocol);
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
    
    							_result = SCardTransmit(_CardContext, ref request, ref sendBytes[0], sendLen, ref request,  ret_Bytes, ref ret_Len);
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
    					SCardReleaseContext(_ReaderContext);
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
    
    	/// <summary>Clase que Implementa los posibles Errores al comunicarse con el Lector de Tarjetas.</summary>
    	internal enum SmartcardErrorCode : uint
    	{
    		[Description("Function succeeded")]
    		None = 0,
    		[Description("An internal consistency check failed.")]
    		InternalError = 2148532225,
    		[Description("The action was canceled by a SCardCancel request.")]
    		Canceled = 2148532226,
    		[Description("The supplied handle was invalid.")]
    		InvalidHandle = 2148532227,
    		[Description("One or more of the supplied parameters could not be properly interpreted.")]
    		InvalidParameter = 2148532228,
    		[Description("Registry startup information is missing or invalid.")]
    		InvalidTarget = 2148532229,
    		[Description("Not enough memory available to complete this command.")]
    		NoMemory = 2148532230,
    		[Description("An internal consistency timer has expired.")]
    		WaitedTooLong = 2148532231,
    		[Description("The data buffer to receive returned data is too small for the returned data.")]
    		InsufficientBuffer = 2148532232,
    		[Description("The specified reader name is not recognized.")]
    		UnknownReader = 2148532233,
    		[Description("The user-specified timeout value has expired.")]
    		Timeout = 2148532234,
    		[Description("The smart card cannot be accessed because of other connections outstanding.")]
    		SharingViolation = 2148532235,
    		[Description("The operation requires a smart card, but not smard card is currently in the device.")]
    		NoSmartcard = 2148532236,
    		[Description("The specified smart card name is not recognized.")]
    		UnknownCard = 2148532237,
    		[Description("The system could not dispose of the media in the requested manner.")]
    		CannotDispose = 2148532238,
    		[Description("The requested protocols are incompatible with the protocol currently in use with the smart card.")]
    		ProtocolMismatch = 2148532239,
    		[Description("The reader or smart card is not ready to accept commands.")]
    		NotReady = 2148532240,
    		[Description("One or more of the supplied parameters values could not be properly interpreted.")]
    		InvalidValue = 2148532241,
    		[Description("The action was canceled by the system, presumably to log off or shut down.")]
    		SystemCanceled = 2148532242,
    		[Description("An internal communications error has been detected.")]
    		CommunicationError = 2148532243,
    		[Description("An internal error has been detected, but the source is unknown.")]
    		UnknownError = 2148532244,
    		[Description("An ATR obtained from the registry is not a valid ATR string.")]
    		InvalidAttribute = 2148532245,
    		[Description("An attempt was made to end a non-existent transaction.")]
    		NotTransacted = 2148532246,
    		[Description("The specified reader is not currently available for use.")]
    		ReaderUnavailable = 2148532248,
    		[Description("The operation has been aborted to allow the server application to exit.")]
    		Shutdown = 2148532248,
    		[Description("The PCI Receive buffer was too small.")]
    		PCITooSmall = 2148532249,
    		[Description("The reader driver does not meet minimal requirements for support.")]
    		ReaderUnsupported = 2148532250,
    		[Description("The reader driver did not produce a unique reader name.")]
    		DuplicateReader = 2148532251,
    		[Description("The smart card does not meet minimal requirements for support.")]
    		CardUnsupported = 2148532252,
    		[Description("The Smart Card Resource Manager is not running.")]
    		NoService = 2148532253,
    		[Description("The Smart Card Resource Manager has shut down.")]
    		ServiceStopped = 2148532254,
    		[Description("An unexpected card error has occured.")]
    		Unexpected = 2148532255,
    		[Description("No primary provider can be found for the smart card.")]
    		ICCInstallation = 2148532256,
    		[Description("The requested order of object creation is not supported.")]
    		ICCCreationOrder = 2148532257,
    		[Description("This smart card does not support the requested feature.")]
    		UnsupportedFeature = 2148532258,
    		[Description("The identified directory does not exist in the smart card.")]
    		DirectoryNotFound = 2148532259,
    		[Description("The identified file does not exist in the smart card.")]
    		FileNotFound = 2148532260,
    		[Description("The supplied path does not represent a smart card directory.")]
    		NoDirectory = 2148532261,
    		[Description("The supplied path does not represent a smart card file.")]
    		NoFile = 2148532262,
    		[Description("Access is denied to this file.")]
    		NoAccess = 2148532263,
    		[Description("The smart card does not have enough memory to store the information.")]
    		WriteTooMany = 2148532264,
    		[Description("There was an error trying to set the smart card file object pointer.")]
    		BadSeek = 2148532265,
    		[Description("The supplied PIN is incorrect.")]
    		InvalidPin = 2148532266,
    		[Description("An unrecognized error code was returned from a layered component.")]
    		UnknownResourceManagement = 2148532267,
    		[Description("The requested certificate does not exist.")]
    		NoSuchCertificate = 2148532268,
    		[Description("The requested certificate could not be obtained.")]
    		CertificateUnavailable = 2148532269,
    		[Description("Cannot find a smart card reader.")]
    		NoReadersAvailable = 2148532270,
    		[Description("A communications error with the smart card has been detected. Retry the operation.")]
    		CommunicationDataLast = 2148532271,
    		[Description("The requested key container does not exist on the smart card.")]
    		NoKeyContainer = 2148532272,
    		[Description("The Smart Card Resource Manager is too busy to complete this operation.")]
    		ServerTooBusy = 2148532273,
    		[Description("The reader cannot communiate with the card, due to ATR string configuration conflicts.")]
    		UnsupportedCard = 2148532325,
    		[Description("The smart card is not responding to a reset.")]
    		UnresponsiveCard = 2148532326,
    		[Description("Power has been removed from the smart card, so that further communication is not possible.")]
    		UnpoweredCard = 2148532327,
    		[Description("The msart card has been reset, so any shared state information is invalid.")]
    		ResetCard = 2148532328,
    		[Description("The smart card has been removed, so further communication is not possible.")]
    		RemovedCard = 2148532329,
    		[Description("Access was denied because of a security violation.")]
    		SecurityViolation = 2148532330,
    		[Description("The card cannot be accessed because th wrong PIN was presented.")]
    		WrongPin = 2148532331,
    		[Description("The card cannot be accessed because the maximum number of PIN entry attempts has been reached.")]
    		PinBlocked = 2148532332,
    		[Description("The end of the smart card file has been reached.")]
    		EndOfFile = 2148532333,
    		[Description("The action was canceled by the user.")]
    		CanceledByUser = 2148532334,
    		[Description("No PIN was presented to the smart card.")]
    		CardNotAuthenticated = 2148532335
    	}
    
    	public enum SCardFunctionReturnCodes : uint
    	{
    		SCARD_S_SUCCESS = 0x0,
    		//'Errors
    		SCARD_E_CANCELLED = 0x80100002,
    		SCARD_E_INVALID_HANDLE = 0x80100003,
    		SCARD_E_INVALID_PARAMETER = 0x80100004,
    		SCARD_E_INVALID_TARGET = 0x80100005,
    		SCARD_E_NO_MEMORY = 0x80100006,
    		SCARD_F_WAITED_TOO_LONG = 0x80100007,
    		SCARD_E_INSUFFICIENT_BUFFER = 0x80100008,
    		SCARD_E_UNKNOWN_READER = 0x80100009,
    		SCARD_E_TIMEOUT = 0x8010000A,
    		SCARD_E_SHARING_VIOLATION = 0x8010000B,
    		SCARD_E_NO_SMARTCARD = 0x8010000C,
    		SCARD_E_UNKNOWN_CARD = 0x8010000D,
    		SCARD_E_CANT_DISPOSE = 0x8010000E,
    		SCARD_E_PROTO_MISMATCH = 0x8010000F,
    		SCARD_E_NOT_READY = 0x80100010,
    		SCARD_E_INVALID_VALUE = 0x80100011,
    		SCARD_E_SYSTEM_CANCELLED = 0x80100012,
    		SCARD_E_INVALID_ATR = 0x80100015,
    		SCARD_E_NOT_TRANSACTED = 0x80100016,
    		SCARD_E_READER_UNAVAILABLE = 0x80100017,
    		SCARD_E_PCI_TOO_SMALL = 0x80100019,
    		SCARD_E_READER_UNSUPPORTED = 0x8010001A,
    		SCARD_E_DUPLICATE_READER = 0x8010001B,
    		SCARD_E_CARD_UNSUPPORTED = 0x8010001C,
    		SCARD_E_NO_SERVICE = 0x8010001D,
    		SCARD_E_SERVICE_STOPPED = 0x8010001E,
    		SCARD_E_UNEXPECTED = 0x8010001F,
    		SCARD_E_ICC_INSTALLATION = 0x80100020,
    		SCARD_E_ICC_CREATEORDER = 0x80100021,
    		SCARD_E_DIR_NOT_FOUND = 0x80100023,
    		SCARD_E_FILE_NOT_FOUND = 0x80100024,
    		SCARD_E_NO_DIR = 0x80100025,
    		SCARD_E_NO_FILE = 0x80100026,
    		SCARD_E_NO_ACCESS = 0x80100027,
    		SCARD_E_WRITE_TOO_MANY = 0x80100028,
    		SCARD_E_BAD_SEEK = 0x80100029,
    		SCARD_E_INVALID_CHV = 0x8010002A,
    		SCARD_E_UNKNOWN_RES_MNG = 0x8010002B,
    		SCARD_E_NO_SUCH_CERTIFICATE = 0x8010002C,
    		SCARD_E_CERTIFICATE_UNAVAILABLE = 0x8010002D,
    		SCARD_E_NO_READERS_AVAILABLE = 0x8010002E,
    		SCARD_E_COMM_DATA_LOST = 0x8010002F,
    		SCARD_E_NO_KEY_CONTAINER = 0x80100030,
    		SCARD_E_SERVER_TOO_BUSY = 0x80100031,
    		SCARD_E_UNSUPPORTED_FEATURE = 0x8010001F,
    		//'The F...not sure
    		SCARD_F_INTERNAL_ERROR = 0x80100001,
    		SCARD_F_COMM_ERROR = 0x80100013,
    		SCARD_F_UNKNOWN_ERROR = 0x80100014,
    		//'The W...not sure
    		SCARD_W_UNSUPPORTED_CARD = 0x80100065,
    		SCARD_W_UNRESPONSIVE_CARD = 0x80100066,
    		SCARD_W_UNPOWERED_CARD = 0x80100067,
    		SCARD_W_RESET_CARD = 0x80100068,
    		SCARD_W_REMOVED_CARD = 0x80100069,
    		SCARD_W_SECURITY_VIOLATION = 0x8010006A,
    		SCARD_W_WRONG_CHV = 0x8010006B,
    		SCARD_W_CHV_BLOCKED = 0x8010006C,
    		SCARD_W_EOF = 0x8010006D,
    		SCARD_W_CANCELLED_BY_USER = 0x8010006E,
    		SCARD_W_CARD_NOT_AUTHENTICATED = 0x8010006F,
    		SCARD_W_INSERTED_CARD = 0x8010006A,
    	}
    
    }
