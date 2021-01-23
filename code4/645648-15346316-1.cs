	partial class Listener /* I named it, to put your code */ {
		SearchRequest _request;
		CancelRequest _request2;
		SearchResponse _response;
		CancelResponse _response2;
		public void ArrangeRequest() {
			_request=new CustomerSearchRequest();
			_request.Company="Test Inc. ";
		}
		void NowhereMethod() {
			var customerIds=_response.Customers.Select(c => c.CustID).ToList();
			foreach(var custID in customerIds) {
				_request2=new CancelRequest();
				_request2.CustID=custID;
				_request2.Company=_request.Company;
			}
		}
		public void ResponseOriginal() {
			var ws=new RunEngine();
			_response=ws.SearchCust(new AppHeader(), _request) as SearchResponse;
			_response2=ws.CancelCust(new AppHeader(), _request2) as CancelResponse;
		}
		public void Response() /* tried to correct */ {
			var ws=new RunEngine();
			_response=ws.SearchCust(new AppHeader(), _request) as SearchResponse;
			var customerIds=_response.Customers.Select(c => c.CustID).ToList();
			foreach(var custID in customerIds) {
				_request2=new CancelRequest();
				_request2.CustID=custID;
				_request2.Company=_request.Company;
				// Seems it should be like this
				// but note the assignment might be wrong, it's according to what `CancelCust` returns
				// for the correct way to make it a list of Customer is appeared in other answers 
				_response2=ws.CancelCust(new AppHeader(), _request2) as CancelResponse;
			}
		}
	}
	partial class Customer {
		public String CustID;
	}
	partial class Response {
		public List<Customer> Customers;
	}
	partial class Request {
		public String Company;
		public String CustID;
	}
	partial class SearchResponse: Response {
	}
	partial class CancelResponse: Response {
	}
	partial class SearchRequest: Request {
	}
	partial class CancelRequest: Request {
	}
	partial class CustomerSearchRequest: SearchRequest {
	}
	partial class AppHeader {
	}
	partial class RunEngine {
		public Response SearchCust(AppHeader appHelper, Request request) {
			// I don't know what it's like
			throw new NotImplementedException();
		}
		public Response CancelCust(AppHeader appHelper, Request request) {
			// I don't know what it's like
			throw new NotImplementedException();
		}
	}
