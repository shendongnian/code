    namespace UnmanagedCpp
    {
    	class MessageBox
    	{
    	public:
    		static void Show(LPCTSTR lpszMessage)
    		{
    			::MessageBoxW(NULL, lpszMessage, L"Message", 0);
    		}
    	};
    }
