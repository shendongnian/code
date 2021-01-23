	using System;
	using System.IO;
	using System.Net;
	using System.Threading;
	using System.Collections;
	using UnityEngine;
	 
	/// <summary>
	///  The RequestState class passes data across async calls.
	/// </summary>
	public class RequestState
	{
		public WebRequest webRequest;
		public string errorMessage;
	 
		public RequestState ()
		{
			webRequest = null;
			errorMessage = null;
		}
	}
	 
	public class WebAsync {
		const int TIMEOUT = 10; // seconds
	 
		/// <summary>
		/// If the URLs returns 404 or connection is broken, it's missing. Else, we suppose it's fine.
		/// </summary>
		/// <param name='url'>
		/// A fully formated URL.
		/// </param>
		/// <param name='result'>
		/// This will bring 'true' if 404 or connection broken and 'false' for everything else.
		/// Use it as this, where "value" is a System sintaxe:
		/// value => your-bool-var = value
		/// </param>
		static public IEnumerator CheckForMissingURL (string url, System.Action<bool> result) {
			result(false);
	 
			Uri httpSite = new Uri(url);
			WebRequest webRequest = WebRequest.Create(httpSite);
	 
			// We need no more than HTTP's head
			webRequest.Method = "HEAD";
			RequestState requestState = new RequestState();
	 
			// Put the request into the state object so it can be passed around
			requestState.webRequest = webRequest;
	 
			// Do the actual async call here
			IAsyncResult asyncResult = (IAsyncResult) webRequest.BeginGetResponse(
				new AsyncCallback(RespCallback), requestState);
	 
			// WebRequest timeout won't work in async calls, so we need this instead
			ThreadPool.RegisterWaitForSingleObject(
				asyncResult.AsyncWaitHandle,
				new WaitOrTimerCallback(ScanTimeoutCallback),
				requestState,
				(TIMEOUT *1000), // obviously because this is in miliseconds
				true
				);
	 
			// Wait until the the call is completed
			while (!asyncResult.IsCompleted) { yield return null; }
	 
			// Deal up with the results
			if (requestState.errorMessage != null) {
				if ( requestState.errorMessage.Contains("404") || requestState.errorMessage.Contains("NameResolutionFailure") ) {
					result(true);
				} else {
					Debug.LogWarning("[WebAsync] Error trying to verify if URL '"+ url +"' exists: "+ requestState.errorMessage);
				}
			}
		}
	 
		static private void RespCallback (IAsyncResult asyncResult) {
	 
			RequestState requestState = (RequestState) asyncResult.AsyncState;
			WebRequest webRequest = requestState.webRequest;
	 
			try {
				webRequest.EndGetResponse(asyncResult);
			} catch (WebException webException) {
				requestState.errorMessage = webException.Message;
			}
		}
	 
		static private void ScanTimeoutCallback (object state, bool timedOut)  { 
			if (timedOut)  {
				RequestState requestState = (RequestState)state;
				if (requestState != null) 
					requestState.webRequest.Abort();
		} else {
			RegisteredWaitHandle registeredWaitHandle = (RegisteredWaitHandle)state;
			if (registeredWaitHandle != null)
				registeredWaitHandle.Unregister(null);
		}
	}
