    #include <Utils.h>
    
    using namespace std;
    using namespace System;
    using namespace System::Text;
    using namespace System::Collections::Generics;
    namespace Interop
    {
        public ref class Utils
        {
        public:
            static List<String ^> ^ GetStrings()
            {
                List<String ^> ^ret = gcnew List<String ^>();
                vector<string> strings = ::GetStrings();
                vector<string>::iterator begin = strings.begin();
                vector<string>::iterator end = strings.end();
                for (; it != end; it++)
                    ret.Add(gcnew String((*it).c_str(), 0, (*it).lenght(), Encoding::UTF-8);
                return ret;
            }
        };
    }
    
