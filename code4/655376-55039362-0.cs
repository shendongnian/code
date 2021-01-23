	BOOL bRes = FALSE;
	//Get IWebBrowser2 from your IE control
	CComPtr<IWebBrowser2> pWebBrowser = this->GetIWebBrowser2();
	if(pWebBrowser)
	{
		HRESULT hr;
		COleVariant varNull;
		SAFEARRAYBOUND psabBounds[1];
		SAFEARRAY *psaHeadFoot;
		hr = S_OK;
		VARIANT vArg;
		BOOL bGot_vArg = FALSE;
		VARIANT vHeadStr, vFootStr;
		long rgIndices;
		VariantInit(&vHeadStr);
		VariantInit(&vFootStr);
		// Initialize header and footer parameters to send to ExecWB().
		psabBounds[0].lLbound = 0;
		psabBounds[0].cElements = 3;
		psaHeadFoot = SafeArrayCreate(VT_VARIANT, 1, psabBounds);
		if(psaHeadFoot)
		{
			// Argument 1: Header
			vHeadStr.vt = VT_BSTR;
			vHeadStr.bstrVal = SysAllocString(L" ");	//Must be at least one space
			if (vHeadStr.bstrVal)
			{
				// Argument 2: Footer
				vFootStr.vt = VT_BSTR;
				vFootStr.bstrVal = SysAllocString(L" ");	//Must be at least one space
				if(vFootStr.bstrVal)
				{
					rgIndices = 0;
					SafeArrayPutElement(psaHeadFoot, &rgIndices, static_cast<void *>(&vHeadStr));
					rgIndices = 1;
					SafeArrayPutElement(psaHeadFoot, &rgIndices, static_cast<void *>(&vFootStr));
					rgIndices = 2;
					SafeArrayPutElement(psaHeadFoot, &rgIndices, static_cast<void *>(&varNull));	//Set stream to NULL as we don't need it
						
					//NOTE: Currently, the SAFEARRAY variant must be passed by using
					// the VT_BYREF vartype when you call the ExecWeb method.
					VariantInit(&vArg);
					vArg.vt = VT_ARRAY | VT_BYREF;
					vArg.parray = psaHeadFoot;
					//Got it
					bGot_vArg = TRUE;
				}
			}
		}
		//Did we get all the vars?
		if(bGot_vArg)
		{
			if(SUCCEEDED(hr = pWebBrowser->ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_PROMPTUSER, &vArg, NULL)))
			{
				//All good
				bRes = TRUE;
			}
		}
		else
		{
			//Use fallback (that will keep the footer & header)
			if(SUCCEEDED(hr = pWebBrowser->ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_PROMPTUSER, varNull, varNull)))
			{
				//Printed via fallback
				bRes = TRUE;
			}
		}
		//Clean up
		VariantClear(&vHeadStr);
		VariantClear(&vFootStr);
		if(psaHeadFoot)
		{
			SafeArrayDestroy(psaHeadFoot);
			psaHeadFoot = NULL;
		}
	}
