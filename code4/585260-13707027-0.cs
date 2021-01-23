    #pragma once
    using namespace System;
    using namespace System::Windows::Automation;
    ref class AutomatedTable {
    public:
        AutomatedTable(const HWND windowHandle);
        property int RowCount {
            int get();
        }
    private:
        AutomationElement^ _tableElement;
    };
AutomatedTable.cpp
