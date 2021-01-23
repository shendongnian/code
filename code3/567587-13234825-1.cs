    class ElementHolder
    {
        public ObservableCollection<Element> ElementsList { get; set; }
        private ExternalService _externalService = new ExternalService();
        private IDisposable _elementSubscription;
        private Subject<Element> _elementSubject = new Subject<Element>();
        public ElementHolder()
        {
            _externalService.ReceivedNewElement += _elementSubject.OnNext;
            _externalService.Subscribe();
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
