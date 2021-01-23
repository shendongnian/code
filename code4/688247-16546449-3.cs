    #pragma once
    using namespace System;
    namespace AlPDFGenV4 
    {
    	public interface class ILogger 
    	{
    	public:
    		virtual void Log( String^ ltxt ) = 0;
    	};
    }
