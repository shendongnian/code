		SAFEARRAYBOUND[] psabBounds = Arrays.InitializeWithDefaultInstances<SAFEARRAYBOUND>(1);
		SAFEARRAY psaHeadFoot;
		// Initialize header and footer parameters to send to ExecWB().
		psabBounds[0].lLbound = 0;
		psabBounds[0].cElements = 3;
		psaHeadFoot = SafeArrayCreate(VT_VARIANT, 1, psabBounds);
		VARIANT vHeadStr = new VARIANT();
		VARIANT vFootStr = new VARIANT();
		VARIANT vHeadTxtStream = new VARIANT();
		int rgIndices;
		VariantInit(vHeadStr);
		VariantInit(vFootStr);
		VariantInit(vHeadTxtStream);
    
		// Argument 1: Header
		vHeadStr.vt = VT_BSTR;
		vHeadStr.bstrVal = SysAllocString("This is my header string.");
		// Argument 2: Footer
		vFootStr.vt = VT_BSTR;
		vFootStr.bstrVal = SysAllocString("This is my footer string.");
    
		// Argument 3: IStream containing header text. Outlook and Outlook 
		// Express use this to print out the mail header. 	
		if ((sMem = (string)CoTaskMemAlloc(512)) == null)
		{
			goto cleanup;
		}
		// We must pass in a full HTML file here, otherwise this 
			 // becomes corrupted when we print.
		sMem = "<html><body><strong>Printed By:</strong> Custom WebBrowser Host 1.0<p></body></html>\0";
		rgIndices = 0;
		SafeArrayPutElement(psaHeadFoot, rgIndices, (object)(vHeadStr));
		rgIndices = 1;
		SafeArrayPutElement(psaHeadFoot, rgIndices, (object)(vFootStr));
		rgIndices = 2;
		SafeArrayPutElement(psaHeadFoot, rgIndices, (object)(vHeadTxtStream));
    
		//NOTE: Currently, the SAFEARRAY variant must be passed by using
				// the VT_BYREF vartype when you call the ExecWeb method.
		VARIANT vArg = new VARIANT();
		VariantInit(vArg);
		vArg.vt = VT_ARRAY | VT_BYREF;
		vArg.parray = psaHeadFoot;
		hr = webOC.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER, vArg, null);
