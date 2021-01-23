    __declspec(dllexport) Status Device_open(Device*& di, const char* uri)
    {
        Status status;
        try
        {
            Device* dl = new Device();
            status = dl->open(uri);
            if (status != OK)
            {
                delete dl;
            }
            else
            {
                di = dl;
            }
        }
        catch (std::bad_alloc const&)
        {
            status = BAD_ALLOC; // Or equivalent failure reason.
        }
        return status;
    }
    __declspec(dllexport) void Device_Close(Device* di)
    {
         // di->close(); Uncomment if destructor does not close().
         delete di;
    }
