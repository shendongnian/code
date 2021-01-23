    // cppClassLib.h
    #pragma once
    using namespace System;
    #define DllExport   __declspec( dllexport )
    // http://msdn.microsoft.com/en-us/library/3y1sfaz2.aspx
    #define maxRowsCpp 100
    namespace cppClassLib {
	public class Class1 {
		public:
			struct columnT {  
				int numberOfRows;
				char *rows[maxRowsCpp];
				char *columnName;
			};
			struct columnT2 {  
				int numberOfRows;
			};
			static DllExport int __thiscall getMatrix(int maxColumns, int maxRows, columnT *matrix[]);
			static DllExport int __thiscall getMatrixNumberOfRowsInColumnZero(int maxColumns, columnT matrix[]);
			static DllExport int __thiscall getMatrixNumberOfRowsInColumnZero2(int maxColumns, columnT2 matrix[]);
			static DllExport void getData(int *totalColumns,
					char** headers[2],
					char** items[2][3]);
			static DllExport char *getHi(void);
			static DllExport char *getHi2(void);
			static DllExport char *getHi3(void);
			static DllExport int getInt(void);
			static DllExport char** getHeaderList(void);
			static DllExport int getHeaderListTwo(int maxsize, char ***result);
	};
