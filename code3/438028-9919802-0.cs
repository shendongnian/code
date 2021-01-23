        public ref class Interop
        {
        public:
            //! Returns the version of this DLL
            static System::String^ GetVersion() {
                return "3.0.0.0";
            }
            //! Processes an image (passed by reference)
            System::Int32^ Process(Bitmap^ image);
        }
