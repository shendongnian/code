    public class ExternalService : IObservable<Element>
    {
        //In this class, you will need to create a Subject<Element> to handle the incoming
        //subscribe requests.  Then you will push Elements into the Subject using OnNext
        private Subject<Element> _elementSubject = new Subject<Element>();
        public IDisposable Subscribe(IObserver<Element> observer)
        {
            return _elementSubject.Subscribe(observer);
        }
        private void HandleNextElement(Element e)
        {
            //Call by whatever code you currently have to do this
            _elementSubject.OnNext(e);
        }
    }
    class ElementHolder
    {
        public ObservableCollection<Element> ElementsList { get; set; }
        private ExternalService _externalService = new ExternalService();
        private IDisposable _elementSubscription;
        public ElementHolder()
        {
            ElementList = new ObservableCollection<Element>();
            _elementSubscription = _externalService.ObserveOnDispatcher().Subscribe(NextElement);
        }
        private void NextElement(Element e)
        {
            Element item = ElementsList.FirstOrDefault(o => o.ID == element.ID);
            if (item == null) {
                _elementList.Add(element);
            }
            else {
                item.Update(element);
            }
        }
    }
